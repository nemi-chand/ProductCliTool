# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

``` sql
select  id,first_name,last_name,email,status,created 
from users 
where id in (3,2,4)
```

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium

``` sql
select first_name, last_name, 
sum(case when list.status=2 then 1 else 0 end) as 'basic', 
sum(case when list.status=3 then 1 else 0 end) as 'premium'  
from listings list 
join users us on us.id = list.user_id
where list.status=2 or list.status=3
group by user_id
```

3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium

``` sql
select first_name, last_name, 
sum(case when list.status=2 then 1 else 0 end) as 'basic', 
sum(case when list.status=3 then 1 else 0 end) as 'premium'  
from listings list 
join users us on us.id = list.user_id
where list.status=2 or list.status=3
group by user_id
having sum(case when list.status=3 then 1 else 0 end) <> 0
```

4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue

``` sql
select us.first_name,us.last_name , cls.currency,sum(cls.price) as 'revenue'  
from listings list
join users us on list.user_id= us.id 
join clicks cls on list.id= cls.listing_id 
where us.status=2 and cls.created as year = 2013
group by us.id,us.first_name,us.last_name,cls.currency
```

5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id

``` sql
  insert into clicks (listing_id, price, currency, created)
  values(3, 4.00, 'USD', current_timestamp);
  select LAST_INSERT_ID();
```

6. Show listings that have not received a click in 2013
- Please return at least: listing_name

``` sql
select name as listing_name 
from listings list
where not exists (select 1 from clicks cls where  YEAR(cls.created)=2013 and cls.listing_id = list.id)
```

7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected

``` sql
select YEAR(c.created) as 'date',
count(c.id) as 'total_listings_clicked',
count(distinct u.id) as 'total_vendors_affected' 
from listings list
join users us on list.user_id= us.id 
join clicks cls on list.id= cls.listing_id 
group by YEAR(cls.created)
```
8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names

``` sql
select first_name, 
last_name, 
group_concat(list.name separator ', ') as 'listing_names'
from listings list
join users us on on us.id = list.user_id
where list.status=2
group by first_name, last_name
```