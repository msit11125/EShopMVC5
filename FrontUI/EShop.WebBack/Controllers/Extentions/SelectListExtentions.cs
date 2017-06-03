using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace EShop.WebBack.Controllers
{
    /// <summary>
    /// SelectList 擴充方法
    /// </summary>
    public static class SelectListExtentions
    {
        //多載一
        public static SelectList ToSelectList<TSource, TValue, TText>(
            this IEnumerable<TSource> source,
            Expression<Func<TSource, TValue>> dataValueField,
            Expression<Func<TSource, TText>> dataTextField)
        {
            string dataName = ExpressionHelper.GetExpressionText(dataValueField);
            string textName = ExpressionHelper.GetExpressionText(dataTextField);

            return new SelectList(source, dataName, textName);

        }

        //多載二
        public static SelectList ToSelectList<TSource, TValue, TText>(
            this IEnumerable<TSource> source,
            Expression<Func<TSource, TValue>> dataValueField,
            Expression<Func<TSource, TText>> dataTextField, TValue defaultValue)
        {
            string dataName = ExpressionHelper.GetExpressionText(dataValueField);
            string textName = ExpressionHelper.GetExpressionText(dataTextField);

            return new SelectList(source, dataName, textName, defaultValue);

        }


    }

}