﻿using InitialProject.Interface;
using InitialProject.Model;
using InitialProject.Repository;
using System.Collections.Generic;

namespace InitialProject.Service;

public class ComplexTourRequestService
{
    private readonly IComplexTourRequestRepository _complexTourRequestRepository;
    private readonly TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());

    public ComplexTourRequestService(IComplexTourRequestRepository repository)
    {
        _complexTourRequestRepository = repository;
    }

    public List<ComplexTourRequest> GetAllPending()
    {
        List<ComplexTourRequest> complexRequests = _complexTourRequestRepository.GetAllPending();
        foreach (ComplexTourRequest complexRequest in complexRequests)
        {
            complexRequest.Requests = tourRequestService.GetAllPendingByComplex(complexRequest.Id);
        }
        return complexRequests;

    }

    public void SetGuide(int id, User loggedInGuide)
    {
        _complexTourRequestRepository.SetGuide(id, loggedInGuide);
    }
}