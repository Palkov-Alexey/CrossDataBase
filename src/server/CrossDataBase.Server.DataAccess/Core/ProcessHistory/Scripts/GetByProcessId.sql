select id as Id,
    process_id as ProcessId,
    status as Status,
    data as Data
from process_history as ph
where ph.process_id = @ProcessId;