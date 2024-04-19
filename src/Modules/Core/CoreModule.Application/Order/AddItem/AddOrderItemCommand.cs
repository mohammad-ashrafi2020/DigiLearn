using Common.Application;

namespace CoreModule.Application.Order.AddItem;

public record AddOrderItemCommand(Guid UserId, Guid CourseId) : IBaseCommand;