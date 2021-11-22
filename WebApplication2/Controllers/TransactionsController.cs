using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Commands;
using WebApplication2.Database;
using WebApplication2.Database.Entities;
using WebApplication2.Helpers;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{


    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly AppDbContext _dbContext;

        private CSVReader csv = new CSVReader();

        List<TransactionEntity> transactionEntities = new List<TransactionEntity>();

        private ITransactionService transactionService;

        public TransactionsController(AppDbContext dbContext, IMapper mapper, ITransactionService transactionService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            this.transactionService = transactionService;



            if (_dbContext.Transactions.Count() == 0)
            {

                foreach (var t in csv.GetTransactionCSVs())
                {

                    TransactionEntity te = new TransactionEntity();
                    te.Id = t.id;
                    te.BeneficiaryName = t.beneficiaryname;
                    te.Amount = Double.Parse(t.amount);
                    te.Currency = t.currency;
                    te.Date = t.date;
                    te.Description = t.description;
                    te.Direction = (TransactionDirection)Enum.Parse(typeof(TransactionDirection), t.direction);
                    te.Kind = (TransactionKind)Enum.Parse(typeof(TransactionKind), t.kind);

                    if (!string.IsNullOrEmpty(t.mcc))
                    {

                        int result;
                        bool flag = int.TryParse(t.mcc, out result);

                        if (flag)
                        {
                            te.MccCode = result;
                            te.Mcc = _dbContext.MccCodes.FirstOrDefault(z => z.Code == te.MccCode);
                        }


                    }




                    //transactionEntities.Add(te);
                    _dbContext.Transactions.Add(te);
                    _dbContext.SaveChanges();
                }
            }

        }

        [HttpPost("Import")]
        public IActionResult Import([FromBody]Transaction transaction) {


            //var files = Request.Form.Files[0];

            return Ok(transaction);

        }



        [HttpGet]
        public IActionResult Get([FromQuery] string? TransactionKind, [FromQuery] string StartDate, [FromQuery] string EndDate,
            [FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrder sortOrder)
        {


            page ??= 1;
            pageSize ??= 10;

            var result = transactionService.GetTransactions(page.Value, pageSize.Value, sortBy, sortOrder);



            //return Ok(_dbContext.Transactions.ToList());

            return Ok(result);
        }


        [HttpPost("{id}/Categorize")]
        public IActionResult Categorize([FromRoute]String id, [FromBody]CategorizeCommand categorizeCommand) {


            var result = transactionService.Categorize(id, categorizeCommand.catcode);

            if (result == null) {
                return NotFound("404");
            }

            return Ok(result);

        }


        [HttpPost("{id}/Split")]
        public IActionResult Split([FromRoute]String Id, [FromBody]SplitTransactionCommand command) {

            if (String.IsNullOrEmpty(Id) || command == null) {
                return BadRequest();
            }

            var result = transactionService.Split(Id, command.Splits);

            return Ok(result);
        
        }

        /*[HttpPost]
        [Route("/Import")]
        public IActionResult Import([FromBody]Transaction transaction) {


       


            return Ok();
        }*/

    }
}
