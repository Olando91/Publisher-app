﻿using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class DeleteArtistByIdRequest : IDeleteArtistByIdRequest
{
    public Guid ArtistId { get; set; }

    public DeleteArtistByIdRequest()
    {
    }

    public DeleteArtistByIdRequest(Guid artistId)
    {
        ArtistId = artistId;
    }

    public bool RequestIsValid()
    {
        if (ArtistId == Guid.Empty)
            return false;

        return true;
    }
}
