using System;
using InitialProject.Dto;

namespace InitialProject.Model;

public class DataEventArgs : EventArgs
{
    public TourToControllerDto Dto { get; set; }
    public TourRequestFilter Request { get; set; }
    public TourRequest AcceptedTourRequest { get; set; }
    public bool CloseDimmedScreen { get; set; } = false;
    public Tour Tour { get; set; }
    public TourBasicInfoDto baisicTour { get; set; }

    public DataEventArgs(TourToControllerDto dto)
    {
        Dto = dto;
        Request = null;
        AcceptedTourRequest = null;
        Tour = null;
    }
    public DataEventArgs(TourBasicInfoDto dto)
    {
        Dto = null;
        Request = null;
        AcceptedTourRequest = null;
        Tour = null;
        baisicTour = dto;
    }

    public DataEventArgs(TourRequestFilter request)
    {
        Dto = null;
        Request = request;
        AcceptedTourRequest = null;
        Tour = null;
    }

    public DataEventArgs(TourRequest acceptedTourRequest)
    {
        AcceptedTourRequest = acceptedTourRequest;
        Dto = null;
        Request = null;
        Tour = null;
    }

    public DataEventArgs(bool closeDimmedScreen)
    {
        CloseDimmedScreen = closeDimmedScreen;
    }

    public DataEventArgs(Tour tour)
    {
        Tour = tour;
    }

}