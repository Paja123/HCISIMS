using InitialProject.Model;
using System.Collections.Generic;

namespace InitialProject.Interface;

public interface IComplexTourRequestRepository
{
    public List<ComplexTourRequest> GetAllPending();

    public void SetGuide(int id, User loggedInGuide);
}