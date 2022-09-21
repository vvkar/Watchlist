﻿namespace Neobank.Test.Domain.Core.DTO
{
    public record FilmDto
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string ResultType { get; init; }
        public string Description { get; init; }
    }
}
