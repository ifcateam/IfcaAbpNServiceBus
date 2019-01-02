using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Volo.Abp.Application.Services;

namespace quarrierAbpMvcApp.TestApi
{
    public class TestTodoAppService : ApplicationService, ITestTodoAppService
    {
        public string ToDo()
        {
            Debug.Print("Todo is ok");
            return "ok";
        }
    }
}
