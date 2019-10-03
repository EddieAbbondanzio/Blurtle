using Microsoft.AspNetCore.Mvc;
using Updog.Application;
using System.Threading.Tasks;
using Updog.Domain;
using System;
using FluentValidation;
using System.Linq;

namespace Updog.Api {
    /// <summary>
    /// End point for managing users of the site.
    /// </summary>
    [Route("api/user")]
    [ApiController]
    public sealed class UserController : ApiController {
        #region Fields
        private QueryHandler<FindUserByUsernameQuery> userFinder;
        private QueryHandler<IsUsernameAvailableQuery> usernameChecker;
        private CommandHandler<RegisterUserCommand> userRegistrar;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new user controller.
        /// </summary>
        public UserController(
                QueryHandler<FindUserByUsernameQuery> userFinder,
                QueryHandler<IsUsernameAvailableQuery> usernameChecker,
                CommandHandler<RegisterUserCommand> userRegistrar
            ) {
            this.userFinder = userFinder;
            this.usernameChecker = usernameChecker;
            this.userRegistrar = userRegistrar;
        }
        #endregion

        #region Publics
        [HttpHead("{username}")]
        public async Task<ActionResult> IsUsernameAvailable(string username) {
            await usernameChecker.Execute(new IsUsernameAvailableQuery(username), ActionResultBuilder);
            return ActionResultBuilder.Build();
        }

        /// <summary>
        /// Retrieve a user from the backend via their username.
        /// </summary>
        /// <param name="username">The username of the user to look for.</param>
        [HttpGet("{username}")]
        public async Task<ActionResult> FindByUsername(string username) {
            await userFinder.Execute(new FindUserByUsernameQuery(username, User), ActionResultBuilder);
            return ActionResultBuilder.Build();
        }

        /// <summary>
        /// Register a new user with the website.
        /// </summary>
        /// <param name="registration">The new user registration</param>
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserRegisterRequest req) {
            await userRegistrar.Execute(new RegisterUserCommand(new UserRegistration(req.Username, req.Password, req.Email)), ActionResultBuilder);
            return ActionResultBuilder.Build();
        }
        #endregion
    }
}