using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Updog.Application;
using System.Threading.Tasks;
using Updog.Domain;

namespace Updog.Application.Tests {
    /// <summary>
    /// Unit tests for the PostPermissionHandler
    /// </summary>
    [TestClass]
    public class PostPermissionHandlerTests {
        #region Fields
        private User user2 = new User();

        private PostPermissionHandler permissionHandler = new PostPermissionHandler();

        private User user = new User() { Id = 3 };
        #endregion

        #region Publics
        [TestMethod]
        public async Task CanEditPostIfUserMatchesCreator() {
            Post p = new Post() {
                User = user
            };

            Assert.IsTrue(await permissionHandler.HasPermission(user, PermissionAction.UpdatePost, p));
        }

        [TestMethod]
        public async Task CantEditPostIfUserIsNotCreator() {
            Post p = new Post() {
                User = user
            };

            Assert.IsFalse(await permissionHandler.HasPermission(user, PermissionAction.UpdatePost, p));
        }

        [TestMethod]
        public async Task CanDeletePostIfUserMatchesCreator() {
            Post p = new Post() {
                User = user
            };

            Assert.IsTrue(await permissionHandler.HasPermission(user, PermissionAction.DeletePost, p));

        }

        [TestMethod]
        public async Task CantDeletePostIfUserIsNotCreator() {
            Post p = new Post() {
                User = user
            };

            Assert.IsFalse(await permissionHandler.HasPermission(user, PermissionAction.DeletePost, p));
        }
        #endregion
    }
}