-- Group by Update Date

SELECT count(*), to_char("UploadDate", 'YYYY/MM/dd') AS Date
FROM "QFiles"
WHERE "AlfrescoUuid" <> '' AND "UploadDate"  BETWEEN '2018-01-01' AND  '2019-12-31'
GROUP BY Date
ORDER BY Date

-- Group by Create Date

SELECT count(*), to_char("CreateDate", 'YYYY/MM/dd') AS Date
FROM "QFiles"
WHERE "CreateDate"  BETWEEN '2018-01-01' AND  '2019-12-31'
GROUP BY Date
ORDER BY Date

-- Validated

SELECT count(*), to_char("CreateDate", 'YYYY/MM/dd') AS Date
FROM "QFiles"
WHERE "Status" = 2
GROUP BY Date
ORDER BY Date