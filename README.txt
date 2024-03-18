event log:

Identity_Code: prefix ID của enterprise theo mỗi user account dùng trong call service.   <prefix ID>_<tên account>
EventName: tên sự kiện ứng với mỗi params sẽ gọi lại cho omni
ListParams: các tham số và value muốn lấy lúc thực hiện cuộc gọi. Ngăn cách bởi dấy phẩy ví dụ to_number(sđt người nhận cuộc gọi), to_alias(tên người gọi)

routerule là kênh chuyển hướng theo omni channel.

các thông tin được lưu :
CALLS: call_id, from, to answerduration, time_start, time_end, ended cause(nguyên nhân end), status
Account là thông tin tài khoản bao gồm username, password được cung cấp bởi INCOM