using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using quarrierAbpMvcApp.TestAbpEventBus.LocalTest;
using Volo.Abp.Application.Services;

namespace quarrierAbpMvcApp.TestApi
{
    public class TestTodoAppService : ApplicationService, ITestTodoAppService
    {
        private readonly TestEventDomainService _domainService;

        public TestTodoAppService(TestEventDomainService domainService)
        {
            _domainService = domainService;
        }

        /// <summary>
        /// 测试event 的Todo
        /// </summary>
        /// <returns></returns>
        public async Task<string> ToDo()
        {
            Debug.Print("Todo is ok");
            await _domainService.TodoEventTestAsyncTask();
            return "ok";
        }
    }
}
