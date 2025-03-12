namespace Applikation.RequestInterfaces;

public interface IEditCoverRequest
{
    Guid CoverId { get; set; }
    string DesignIdea { get; set; }
    bool DigitalOnly { get; set; }
}
