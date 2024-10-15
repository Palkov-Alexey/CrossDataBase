select id as Id,
    process_id as ProcessId,
    status as Status,
    node_id	as NodeId,
    data as Data
from process_history as ph
where ph.process_id = @ProcessId;