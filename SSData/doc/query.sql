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
delete from t_ssdata_split;

select count(1) from t_billtran_items;


select * 
into FINANCE_M20
from FINANCE_M19;

delete from FINANCE_M20;

insert into FINANCE_M20 (  MNC_GRP_SS2, MNC_GRP_SS2_DSC ) values ('1','ค่าห้อง และค่าอาหาร');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( '2','ค่าอวัยวะเทียม และอุปกรณ์ในการบำบัด');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( '3','ค่ายา และสารอาหาร');
--insert into FINANCE_M20 (  MNC_GRP_SS = '4', MNC_GRP_SS_DSC = 'ค่าเวชภัณฑ์ที่มิใช่ยา' where MNC_GRP_SS = '01'
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( '5','ค่าเวชภัณฑ์ที่มิใช่ยา');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( '6','ค่าบริการโลหิต และส่วนประกอบของโลหิต' );
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( '7','ค่าตรวจวินิจฉัยทางเทคนิคการแพทย์');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( '8','ค่าตรวจวินิจฉัย และรักษาทางรังสีวิทยา');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( '9', 'ค่าตรวจวินิจฉัยโดยวิธีพิเศษอื่นๆ');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'A','ค่าอุปกรณ์ของใช้ และเครื่องมือฯ');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'B','ค่าทำหัตถการ และวิสัญญี');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'C','ค่าบริการทางการพยาบาล');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'D', 'ค่าบริการทางทันตกรรม');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'E','ค่าบริการทางกายภาพบำบัด');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'F','ค่าบริการฝังเข็มและค่าบริการให้การบำบัดของผู้ประกอบโรคศิลปะอื่นๆ');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'G','ค่าบริการอื่นๆ');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'H','ค่าห้องผ่าตัด/ห้องคลอด');
insert into FINANCE_M20 (  MNC_GRP_SS2 , MNC_GRP_SS2_DSC ) values ( 'I','ค่าธรรมเนียมบุคลากรทางการแพทย์');

ALTER TABLE FINANCE_M01
add MNC_GRP_SS2 varchar(255) ;