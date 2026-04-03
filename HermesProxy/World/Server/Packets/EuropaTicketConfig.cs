namespace HermesProxy.World.Server.Packets;

public class EuropaTicketConfig
{
	public bool TicketsEnabled;

	public bool BugsEnabled;

	public bool ComplaintsEnabled;

	public bool SuggestionsEnabled;

	public SavedThrottleObjectState ThrottleState;

	public void Write(WorldPacket data)
	{
		data.WriteBit(this.TicketsEnabled);
		data.WriteBit(this.BugsEnabled);
		data.WriteBit(this.ComplaintsEnabled);
		data.WriteBit(this.SuggestionsEnabled);
		this.ThrottleState.Write(data);
	}
}
