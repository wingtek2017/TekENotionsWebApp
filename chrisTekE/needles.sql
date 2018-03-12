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

update needledescriptionlookup set systemdescription = 'Circular US 8 (5mm) 16 in'
WHERE ravelrydescription = 'US 8 (5mm) 16" cir'

insert into [NeedleDescriptionLookup]
select nt.description, NULL, nt.id
from needle_types nt

delete from NeedleDescriptionLookup


