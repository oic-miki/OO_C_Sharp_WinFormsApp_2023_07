using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public enum Role
    {

        None,
        Administrator,

    }

    public class RoleMap
    {

        private static RoleMap roleMap = new RoleMap();

        private Dictionary<Role, String> aliasMap = new Dictionary<Role, String>();

        private RoleMap()
        {

            // すべての役割名をマッピングする
            aliasMap.Add(Role.None, "利用者");
            aliasMap.Add(Role.Administrator, "管理者");

        }

        public static RoleMap get()
        {

            return roleMap;

    }

        public String[] aliases()
        {

            return aliasMap.Values.ToArray();

        }

        public String acquireAlias(Role role)
        {

            Debug.Assert(role != null);

            String alias = aliasMap[role];

            if (alias is not null)
            {

                return alias;

            }

            return "";

        }

        public Role acquireRole(String alias)
        {

            Debug.Assert(alias != null);

            foreach (Role role in aliasMap.Keys)
            {

                if (aliasMap[role].Equals(alias))
                {

                    return role;

                }

            }

            return Role.None;

        }

    }

}