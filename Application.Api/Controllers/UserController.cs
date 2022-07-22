using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork? db;

        public UserController(IUnitOfWork database)
        {
            this.db = database;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tx = await this.db!.BeginTransactionAsync(CancellationToken.None);
            try
            {
                var user = await this.db!.User.FindByIdAsync(92, CancellationToken.None);

                if (user == null)
                    throw new Exception("User not found.");

                user.UserName = "teste";

                var result = this.db!.User!.Update(user);

                await this.db!.SaveChanges(CancellationToken.None);

                await tx!.CommitAsync(CancellationToken.None);

                return Ok(result);
            }
            catch (Exception ex)
            {
                await tx!.RollbackAsync(CancellationToken.None);

                return BadRequest(ex.Message);
            }
        }
    }
}
