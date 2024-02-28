namespace MvcCoreSession.Models
{
    public class Class1
    {
        private IHttpContextAccessor contextAccessor;

        public Class1(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public void MetodoSesion()
        {
            this.contextAccessor.HttpContext.Session.GetString("KEY");
        }
    }
}
