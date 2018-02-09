 

INSERT INTO public."Publications"(
	id, header, image_path, tags, author_id, public_date)
	VALUES (uuid_generate_v4(),
'header2',
'C:\Users\LenSher\Downloads\fon\arthas.jpg',
'wow;arthas',
(SELECT "Id" from public."AspNetUsers" LIMIT 1),
'1997-07-16T19:20:30+06:00');

