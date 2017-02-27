
--Finding reservations that conflict with our searched dates. 2/20 is @start_date and 03/04 is @end_date
SELECT r.site_id FROM site s 
join reservation r ON s.site_id = r.site_id
WHERE (('02/26/2017' > r.from_date AND '02/26/2017' < r.to_date)OR('02/27/2017' > r.from_date AND '02/27/2017' < r.to_date)OR('02/26/2017' < r.from_date AND '02/27/2017' > r.to_date))

--Finding sites under our searched campground. The 4 is user input @campground_id
SELECT s.site_number,s.max_occupancy,s.accessible,s.max_rv_length,s.utilities,cg.daily_fee FROM site s
join campground cg ON cg.campground_id = s.campground_id
WHERE cg.campground_id = 4

--Combining the two above ASSUMING THIS WORKS
SELECT TOP 5 s.site_number,s.max_occupancy,s.accessible,s.max_rv_length,s.utilities,cg.daily_fee FROM site s
join campground cg ON cg.campground_id = s.campground_id
WHERE cg.campground_id = 4 AND s.site_id NOT IN (SELECT r.site_id FROM site s 
join reservation r ON s.site_id = r.site_id
WHERE (('02/26/2017' > r.from_date AND '02/26/2017' < r.to_date)OR('02/27/2017' > r.from_date AND '02/27/2017' < r.to_date)OR('02/26/2017' < r.from_date AND '02/27/2017' > r.to_date))) 

--Cleaned up for pasting into C#
SELECT s.site_number,s.max_occupancy,s.accessible,s.max_rv_length,s.utilities,cg.daily_fee FROM site s join campground cg ON cg.campground_id = s.campground_id WHERE cg.campground_id = @campground_id AND s.site_id NOT IN (SELECT r.site_id FROM site s join reservation r ON s.site_id = r.site_id WHERE ((@arrival_date > r.from_date AND @arrival_date < r.to_date)OR(@departure_date > r.from_date AND @departure_date < r.to_date)OR(@arrival_date < r.from_date AND @departure_date > r.to_date))) 

--Putting this into C#
INSERT INTO reservation (site_id,name,from_date,to_date) VALUES (@site_id,@name,@arrivalDate,@departureDate)

--Searching through reservations for the reservationID we just made.
SELECT r.reservation_id FROM reservation r WHERE r.name = @name AND r.from_date = @arrivalDate AND r.to_date = @departureDate

--Checking reservations made from the program
SELECT * FROM reservation WHERE reservation.reservation_id > 47

--TESTING Acadia Campground ID = 2, site num = 9, Joe O Does Windows, 2/25 - 2/27, Res ID = 54
SELECT cg.campground_id,s.site_number,r.reservation_id,r.from_date,r.to_date,r.name FROM reservation r 
join site s ON s.site_id = r.site_id
join campground cg ON cg.campground_id = s.campground_id
WHERE s.site_id = 3

--Trying to do bonus- filter out offseason
SELECT TOP 5 s.site_number,s.max_occupancy,s.accessible,s.max_rv_length,s.utilities,cg.daily_fee FROM site s
join campground cg ON cg.campground_id = s.campground_id
WHERE cg.campground_id = 4 AND
(((DATEPART(m, '02/26/2017') >= cg.open_from_mm)AND(DATEPART(m, '02/26/2017') < cg.open_to_mm))
AND(DATEPART(m, '02/27/2017') >= cg.open_from_mm)AND(DATEPART(m, '02/27/2017') < cg.open_to_mm))
AND s.site_id
NOT IN (SELECT r.site_id FROM site s 
join reservation r ON s.site_id = r.site_id
WHERE 
((('02/26/2017' > r.from_date AND '02/26/2017' < r.to_date)
OR('02/27/2017' > r.from_date AND '02/27/2017' < r.to_date)
OR('02/26/2017' < r.from_date AND '02/27/2017' > r.to_date)
OR('02/26/2017' = r.from_date AND '02/27/2017' = r.to_date))))

--IS THIS GONNA WORK?!?!
SELECT TOP 5 s.site_number,s.max_occupancy,s.accessible,s.max_rv_length,s.utilities,cg.daily_fee FROM site s join campground cg ON cg.campground_id = s.campground_id WHERE cg.campground_id = 4 AND (((DATEPART(m, @arrival_date) >= cg.open_from_mm)AND(DATEPART(m, @arrival_date) < cg.open_to_mm)) AND(DATEPART(m, @departure_date) >= cg.open_from_mm)AND(DATEPART(m, @departure_date) < cg.open_to_mm)) AND s.site_id NOT IN (SELECT r.site_id FROM site s join reservation r ON s.site_id = r.site_id WHERE (((@arrival_date > r.from_date AND @arrival_date < r.to_date) OR(@departure_date > r.from_date AND @departure_date < r.to_date) OR(@arrival_date < r.from_date AND @departure_date > r.to_date) OR(@arrival_date = r.from_date AND @departure_date = r.to_date))))
--Old One "SELECT TOP 5 s.site_number,s.max_occupancy,s.accessible,s.max_rv_length,s.utilities,cg.daily_fee FROM site s join campground cg ON cg.campground_id = s.campground_id WHERE cg.campground_id = @campground_id AND s.site_id NOT IN (SELECT r.site_id FROM site s join reservation r ON s.site_id = r.site_id WHERE ((@arrival_date > r.from_date AND @arrival_date < r.to_date)OR(@departure_date > r.from_date AND @departure_date < r.to_date)OR(@arrival_date < r.from_date AND @departure_date > r.to_date)OR(@arrival_date = r.from_date AND @departure_date = r.to_date)))";
