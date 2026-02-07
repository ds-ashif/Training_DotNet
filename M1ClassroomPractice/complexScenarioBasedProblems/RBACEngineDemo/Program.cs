using System;
using System.Collections.Generic;

namespace RBACEngineDemo
{
    #region Enums

    /// <summary>
    /// Available user roles.
    /// </summary>
    public enum Role
    {
        Admin,
        Manager,
        Agent
    }

    /// <summary>
    /// Permissions supported by system.
    /// </summary>
    public enum Permission
    {
        CreateLoan,
        ApproveLoan,
        RejectLoan,
        ViewAll,
        ViewSelf
    }

    #endregion

    #region Core Models

    /// <summary>
    /// System user.
    /// </summary>
    public class User
    {
        public string UserId { get; }
        public string Name { get; }
        public Role Role { get; }

        /// <summary>
        /// Used only for managers (approval limit).
        /// </summary>
        public decimal ApprovalLimit { get; }

        public User(string id, string name, Role role, decimal limit = 0)
        {
            UserId = id;
            Name = name;
            Role = role;
            ApprovalLimit = limit;
        }
    }

    /// <summary>
    /// Resource being accessed (e.g., loan).
    /// </summary>
    public class Resource
    {
        public string ResourceId { get; }
        public string OwnerUserId { get; }

        /// <summary>
        /// Loan amount (used in approval validation).
        /// </summary>
        public decimal Amount { get; }

        public Resource(string id, string ownerUserId, decimal amount)
        {
            ResourceId = id;
            OwnerUserId = ownerUserId;
            Amount = amount;
        }
    }

    #endregion

    #region RBAC Engine

    /// <summary>
    /// Role-Based Access Control engine.
    /// Central authorization logic.
    /// </summary>
    public class AuthorizationService
    {
        /// <summary>
        /// Static role-permission mapping.
        /// </summary>
        private readonly Dictionary<Role, HashSet<Permission>> _rolePermissions = new()
        {
            {
                Role.Admin,
                new HashSet<Permission>
                {
                    Permission.CreateLoan,
                    Permission.ApproveLoan,
                    Permission.RejectLoan,
                    Permission.ViewAll,
                    Permission.ViewSelf
                }
            },
            {
                Role.Manager,
                new HashSet<Permission>
                {
                    Permission.CreateLoan,
                    Permission.ApproveLoan,
                    Permission.RejectLoan,
                    Permission.ViewAll,
                    Permission.ViewSelf
                }
            },
            {
                Role.Agent,
                new HashSet<Permission>
                {
                    Permission.CreateLoan,
                    Permission.ViewSelf
                }
            }
        };

        /// <summary>
        /// Authorization decision entry point.
        /// </summary>
        public bool Authorize(User user, Permission permission, Resource resource)
        {
            // Step 1: Role must allow permission
            if (!_rolePermissions.TryGetValue(user.Role, out var perms) || !perms.Contains(permission))
                return false;

            // Step 2: Apply rule-based constraints
            return ApplyBusinessRules(user, permission, resource);
        }

        /// <summary>
        /// Additional rule validation beyond role mapping.
        /// </summary>
        private bool ApplyBusinessRules(User user, Permission permission, Resource resource)
        {
            switch (user.Role)
            {
                case Role.Admin:
                    // Admin unrestricted
                    return true;

                case Role.Agent:
                    // Agent can only access own resources
                    if (permission == Permission.ViewSelf)
                        return resource.OwnerUserId == user.UserId;

                    // Agents cannot access others
                    return false;

                case Role.Manager:
                    // Manager approval limited by amount
                    if (permission == Permission.ApproveLoan)
                        return resource.Amount <= user.ApprovalLimit;

                    return true;

                default:
                    return false;
            }
        }
    }

    #endregion

    #region Demo Program

    /// <summary>
    /// Demonstration of RBAC authorization checks.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var authService = new AuthorizationService();

            var admin = new User("U1", "AdminUser", Role.Admin);
            var manager = new User("U2", "ManagerUser", Role.Manager, 50000);
            var agent = new User("U3", "AgentUser", Role.Agent);

            var loan = new Resource("L1", "U3", 40000);

            Console.WriteLine("Admin approve: " + authService.Authorize(admin,Permission.ApproveLoan, loan));

            Console.WriteLine("Manager approve: " + authService.Authorize(manager, Permission.ApproveLoan, loan));

            Console.WriteLine("Agent view own: " + authService.Authorize(agent, Permission.ViewSelf, loan));

            Console.WriteLine("Agent approve: " + authService.Authorize(agent,Permission.ApproveLoan, loan));
        }
    }

    #endregion
}
