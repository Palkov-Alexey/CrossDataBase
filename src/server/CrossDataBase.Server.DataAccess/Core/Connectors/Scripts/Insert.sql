insert into connector (process_id, from_node, [from], to_node, [to])
values (@ProcessId, @FromNode, @From, @ToNode, @To)
returning id;