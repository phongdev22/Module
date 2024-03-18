namespace Module.Models
{
  public class CallResponse
  {
    public required string call_status { get; set; }
    public required string request_from_user_id { get; set; }
    public required string account_sid { get; set; }
    public required string call_id { get; set; }
    public required Info from { get; set; }
    public required Info to { get; set; }
    public long project_id { get; set; }
    public long timestamp_ms { get; set; }
    public string? type { get; set; }
    public string? callCreatedReason { get; set; }
    public string? endCallCause { get; set; }
    public string? endedBy { get; set; }
    public string? callType { get; set; }
    public long duration { get; set; }
    public long answerDuration { get; set; }
  }

  public class Info
  {
    public required string number { get; set; }
    public required string alias { get; set; }
    public bool isOnline { get; set; }
    public string? type { get; set; }
  }
}


/*
 
{
  endCallCause: '486 Busy Here',
  actorType: '',
  original: false,
  peerToPeer: true,
  timestamp_ms: 1710493163225,
  endedBy: 'INTERNAL',
  type: 'stringee_call',
  callType: 'CALL',
  call_id: 'call-vn-1-Z6JFTOVDUQ-1710441223965',
  actor: '',
  duration: 10,
  callCreatedReason: 'CLIENT_MAKE_CALL',
  call_status: 'ended',
  event_id: 'OI175MVQ57-1708736338885',
  project_id: 1237100,
  serial: 1,
  answerDuration: 0,
  request_from_user_id: 'phongzann',
  account_sid: 'ACb55c0c67c584e3ab28191e085e88352c',
  from: {
    number: 'phongzann',
    alias: 'phongzann',
    is_online: true,
    type: 'internal'
  },
  clientCustomData: '',
  to: {
    number: 'phongzann123',
    alias: 'phongzann123',
    is_online: true,
    type: 'internal'
  }
}

 */