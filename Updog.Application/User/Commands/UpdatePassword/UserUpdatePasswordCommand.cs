using Updog.Domain;

namespace Updog.Application {
    /// <summary>
    /// Parameters to update a user's password.
    /// </summary>
    public sealed class UserUpdatePasswordCommand : AuthenticatedCommand {
        #region Properties
        public UserUpdatePassword UpdatePassword { get; }
        #endregion

        #region Constructor(s)
        public UserUpdatePasswordCommand(UserUpdatePassword data, User user) : base(user) {
            UpdatePassword = data;
        }
        #endregion
    }
}