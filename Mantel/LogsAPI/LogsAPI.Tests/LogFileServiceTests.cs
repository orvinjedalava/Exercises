using FluentAssertions;
using FluentAssertions.Execution;
using LogsAPI.Interfaces.Services;
using LogsAPI.Models;
using LogsAPI.Services;
using LogsAPI.Tests.TestData;
using System.Collections;
using System.Net;

namespace LogsAPI.Tests
{
    public class LogFileServiceTests
    {
        private readonly ILogFileService _service;

        public LogFileServiceTests()
        {
            _service = new LogFileService();
        }

        [Theory, ClassData(typeof(GenerateLogItemTestData))]
        public void GenerateLogItem_Test(
            string input,
            IPAddress expectedIPAddress,
            DateTime expectedTimestamp
            )
        {
            LogItem result = _service.GenerateLogItem(input);

            using (new AssertionScope())
            {
                result.IPAddress.Should().Be(expectedIPAddress);
                //result.Timestamp.Should().Be(expectedTimestamp);
            }
        }
    }
}