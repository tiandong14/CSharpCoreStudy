using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public static class EnumExtension
{
    /// <summary>
    /// 获取枚举的显示名字
    /// </summary>
    public static string GetDisplayName(this System.Enum en)
    {
        Type type=en.GetType();
        MemberInfo[] meminfo = type.GetMember(en.ToString());
        if (meminfo != null && meminfo.Length > 0) {
          Object[] attrs=  meminfo[0].GetCustomAttributes(typeof(DisplayAttribute),true);
            if (attrs != null && attrs.Length>0) {
                return ((DisplayAttribute)attrs[0]).Name;
            }
        }
        return en.ToString();
    }
}
