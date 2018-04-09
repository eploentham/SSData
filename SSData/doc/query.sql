declare @TableName sysname = 'b_drugcatalogue'
    declare @Result varchar(max) = 'public class ' + @TableName + '
    {'

    select @Result = @Result + '
        public String ' + ColumnName + ' { get; set; }
    '
    from
    (
        select
            replace(col.name, ' ', '_') ColumnName,
            column_id ColumnId
        from sys.columns col
            join sys.types typ on
                col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id
        where object_id = object_id(@TableName)
    ) t
    order by ColumnId

    set @Result = @Result  + '
    }'

    print @Result



delete from t_ssdata;
delete from t_ssdata_visit;
delete from t_billtran;
delete from t_billtran_items;
delete from t_billdisp;
delete from t_billdisp_items;
delete from t_opservices;

select count(1) from t_billtran_items;