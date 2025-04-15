insert into node (process_id, type, pos_x, pos_y, fields, data)
values (@ProcessId, @Type, @PosX, @PosY, @Fields, @Data)
returning id;