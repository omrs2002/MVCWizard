using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVCWizard.Web.Extensions.Modal
{
    public static class ModalExt
    {
        public static string GetModalErrors(this ModelStateDictionary modal)
        {
            if(modal.IsValid) return "";
            string messages = string.Join(Environment.NewLine, modal.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            return messages;
        }

    }
}
