using System;
using System.Linq;

namespace Updog.Domain {
    public partial class User {
        public static string[] BannedSlurs = new string[] {
            "fag",
            "faggot",
            "nigger",
            "nigga"
        };

        public static string[] BannedUsernames = new string[]
            {
                "account",
                "accounts",
                "admin",
                "administrator",
                "advertising",
                "affiliate",
                "affiliates",
                "analytics",
                "auth",
                "authentication",
                "anon",
                "anonymous",
                "backup",
                "banner",
                "banners",
                "billing",
                "blog",
                "blogs",
                "bot",
                "bots",
                "business",
                "chat",
                "cache",
                "calender",
                "careers",
                "client",
                "code",
                "contact",
                "data",
                "dashboard",
                "default",
                "dev",
                "directory",
                "docs",
                "domain",
                "download",
                "downloads",
                "edit",
                "editor",
                "email",
                "ecommerce",
                "forum",
                "forums",
                "favorite",
                "feedback",
                "follow",
                "file",
                "files",
                "free",
                "guest",
                "help",
                "home",
                "homepage",
                "host",
                "hosting",
                "hostname",
                "html",
                "http",
                "https",
                "httpd",
                "hpg",
                "info",
                "information",
                "image",
                "images",
                "imap",
                "index",
                "invite",
                "intranet",
                "indice",
                "login",
                "logout",
                "list",
                "lists",
                "mail",
                "message",
                "mailer",
                "mailing",
                "manager",
                "marketing",
                "master",
                "message",
                "movie",
                "music",
                "name",
                "network",
                "news",
                "newsletter",
                "nickname",
                "notes",
                "online",
                "operator",
                "order",
                "orders",
                "page",
                "pages",
                "password",
                "pics",
                "photo",
                "photos",
                "plugin",
                "plugins",
                "postmaster",
                "posts",
                "profile",
                "project",
                "promo",
                "public",
                "sale",
                "sales",
                "sample",
                "samples",
                "script",
                "scripts",
                "secure",
                "send",
                "service",
                "shop",
                "signup",
                "signin",
                "search",
                "security",
                "settings",
                "setting",
                "setup",
                "site",
                "sites",
                "sitemap",
                "smtp",
                "stage",
                "staging",
                "start",
                "subscribe",
                "subscribed",
                "subdomain",
                "support",
                "stat",
                "stats",
                "static",
                "status",
                "store",
                "stores",
                "system",
                "tech",
                "test",
                "theme",
                "themes",
                "update",
                "updog",
                "upload",
                "user",
                "username",
                "usage",
                "video",
                "videos",
                "visitor",
                "www",
                "webmail",
                "website",
                "websites",
                "webmaster",
                "workshop",
            };

        /// <summary>
        /// Check to see if a username is banned, or racist.
        /// </summary>
        /// <param name="username">The username to test.</param>
        /// <returns>True if the username should not be allowed.</returns>
        public static bool IsUsernameBanned(string username) {
            bool isBanned = User.BannedUsernames.Any(u => String.Equals(username, u, StringComparison.OrdinalIgnoreCase));

            if (isBanned) {
                return true;
            }

            return BannedSlurs.Any(s => username.Contains(s, StringComparison.OrdinalIgnoreCase));
        }
    }
}