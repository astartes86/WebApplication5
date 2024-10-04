using FluentAssertions;
using FluentValidation;
using Moq;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Commands.CRUD.Delete;
using WebApplication5.Commands.CRUD.Update;
using WebApplication5.DAL;
using WebApplication5.Interfaces;


namespace unittests.Handlers
{
    public class HandlerTests
    {
        private readonly Mock<IRepository<Note>> repositoryMock;

        public HandlerTests()
        {
            repositoryMock = new ();
        }

        [Fact]
        public async Task CreateNoteCommandHandlerAsync()
        {
            // Arrange
            Mock<IValidator<CreateCommand<Note>>> validatorMock = new();
            var note = new Note { Header = "Test Header", Text = "Test Text" };
            var command = new CreateCommand<Note> { Entity = note };
            var handler = new CreateHandler<Note>(repositoryMock.Object, validatorMock.Object);

            repositoryMock.Setup(repo => repo.Add(It.IsAny<Note>())).ReturnsAsync(note); // Убедитесь, что метод Add возвращает созданный объект

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(note);
            repositoryMock.Verify(repo => repo.Add(It.IsAny<Note>()), Times.Once);
        }

        [Fact]
        public async Task DeleteNoteCommandHandlerAsync()
        {
            // Arrange
            Mock<IValidator<DeleteCommand<Note>>> validatorMock = new();
            var note = new Note { Header = "Test Header", Text = "Test Text" };
            var command = new DeleteCommand<Note> { Entity = note };
            var handler = new DeleteHandler<Note>(repositoryMock.Object, validatorMock.Object);

            repositoryMock.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync(note); // Убедитесь, что метод Add возвращает созданный объект

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(note);
            repositoryMock.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task UpdateNoteCommandHandlerAsync()
        {
            // Arrange
            Mock<IValidator<UpdateCommand<Note>>> validatorMock = new();
            var note = new Note { Header = "Test Header", Text = "Test Text" };
            var command = new UpdateCommand<Note> { Entity = note };
            var handler = new UpdateHandler<Note>(repositoryMock.Object, validatorMock.Object);

            repositoryMock.Setup(repo => repo.Update(It.IsAny<Note>())).ReturnsAsync(note); // Убедитесь, что метод Add возвращает созданный объект

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(note);
            repositoryMock.Verify(repo => repo.Update(It.IsAny<Note>()), Times.Once);
        }
    }
}