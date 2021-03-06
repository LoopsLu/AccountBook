﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountBook.Helpers
{
    public static class EnumDataHelper<T>
    {
        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}