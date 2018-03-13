/*

select * from UserNeedleInventory where id = 12

select * from needle_sizes where id = 8

select * from needle_types
where id = 118

select * from pattern_needle_size where needle_size_id = 8

select * from pattern where id = 29
select * from photo where id = 1092

select distinct nt.description, ns.id, null
from needle_types nt
join needle_sizes ns

delete from NeedleDescriptionLookup where id > 

insert into [NeedleDescriptionLookup]
select nt.description, NULL, nt.id
from needle_types nt


*/


select needletype +  ' ' + needlesize + ' ' + needlelength, systemname from UserNeedleInventory

update userneedleinventory set ravelryId = 121, ravelryName = 
'US 10½(6.5mm) 16" cir'
 where id = 21



select * from NeedleDescriptionLookup where systemdescription = 'Circular US 10.5 (6.5mm) 16 in'



update NeedleDescriptionLookup set systemDescription =
Replace(systemDescription, '½', '.5 ') from
NeedleDescriptionLookup where systemDescription like 'Circular Circular%' 

select * from userneedleinventory ui
 join needledescriptionlookup nlu
on nlu.systemDescription = ui.systemName


update NeedleDescriptionLookup set systemdescription = 'Double Pts US 00 (7mm) std' where ravelryDescription = 'US (7mm) std dp'

update NeedleDescriptionLookup set systemdescription = 'Double Pts US 00 (7mm) std' where ravelryDescription = 'US 1 (2.25mm) 10" st'