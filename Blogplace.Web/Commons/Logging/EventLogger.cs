﻿using ILogger = Serilog.ILogger;

namespace Blogplace.Web.Commons.Logging;

public interface IEventLogger
{
    void UserSignedIn(Guid userId);
    void UserSignedOut(Guid userId);
    void UserCreated(Guid userId);
    void UserUpdatedProfile(Guid userId);
    void UserCreatedArticle(Guid userId, Guid articleId);
    void UserDeletedArticle(Guid userId, Guid articleId);
    void UserUpdatedArticle(Guid userId, Guid articleId);
    void UserViewedArticle(Guid userId, Guid articleId);
    void EmailSent(string email, string subject);
}

public class EventLogger(ILogger logger) : IEventLogger
{
    private const string LOG_TEMPLATE = "{Event} {Payload}";

    public void UserSignedIn(Guid userId)
        => this.Info(nameof(this.UserSignedIn), new { UserId = userId });

    public void UserSignedOut(Guid userId)
        => this.Info(nameof(this.UserSignedOut), new { UserId = userId });

    public void UserCreated(Guid userId)
        => this.Info(nameof(this.UserCreated), new { UserId = userId });

    public void UserUpdatedProfile(Guid userId)
        => this.Info(nameof(this.UserUpdatedProfile), new { UserId = userId });

    public void UserCreatedArticle(Guid userId, Guid articleId)
        => this.Info(nameof(this.UserCreatedArticle), new { UserId = userId, ArticleId = articleId });

    public void UserUpdatedArticle(Guid userId, Guid articleId)
        => this.Info(nameof(this.UserUpdatedArticle), new { UserId = userId, ArticleId = articleId });

    public void UserDeletedArticle(Guid userId, Guid articleId)
        => this.Info(nameof(this.UserDeletedArticle), new { UserId = userId, ArticleId = articleId });

    public void UserViewedArticle(Guid userId, Guid articleId)
        => this.Info(nameof(this.UserViewedArticle), new { UserId = userId, ArticleId = articleId });

    public void EmailSent(string email, string subject)
        => this.Info(nameof(this.EmailSent), new { Email = email, Subject = subject });

    private void Info<T>(string eventName, T payload)
        => logger.Information(LOG_TEMPLATE, eventName, payload);
}
