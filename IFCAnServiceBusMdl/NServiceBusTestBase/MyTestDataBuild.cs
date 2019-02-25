using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace NServiceBusTestBase
{
    public class MyTestDataBuild : ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private TestData _testData;

        public MyTestDataBuild(IGuidGenerator guidGenerator, TestData testData)
        {
            _guidGenerator = guidGenerator;
            _testData = testData;
        }

        public void Build()
        {

        }
    }
}
