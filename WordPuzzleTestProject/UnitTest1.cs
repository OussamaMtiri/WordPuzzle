using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Word_puzzle;
namespace WordPuzzleTestProject
{
    public class Tests
    {
    
        [Test]
        public void LoadTextAndGetList()
        {
            //Arrange
            //var employeeToEdit = EmployeesMockData.GetSampleEmployee();
           
            //Act
            //var okResult = employeesController.EditEmployee(employeeToEdit);
            var wordsArray = _searchService.LoadTextAndGetList();

            //Assert
            //Assert.IsType<NotFoundObjectResult>(okResult);
            Assert.Positive(wordsArray.Length);
            //Assert.Pass();
        }
    }
}