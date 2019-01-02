using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace quarrierAbpMvcApp.TestApi
{
    public interface ITestTodoAppService : IApplicationService
    {
        string ToDo();
    }
}
