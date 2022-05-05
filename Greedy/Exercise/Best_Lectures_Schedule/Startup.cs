string? lecturesCountInput = Console.ReadLine();

if (lecturesCountInput is null) return;

int lecturesCount = int.Parse(lecturesCountInput.Replace("Lectures:", ""));

List<Lecture> lectures = new(lecturesCount);

for (int i = 0; i < lecturesCount; i++)
{
    string? lectureInput = Console.ReadLine();

    if (lectureInput is null) continue;

    string[] lectureParts = lectureInput
        .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);

    if (lectureParts.Length != 3) continue;

    string name = lectureParts[0];
    int startTime = int.Parse(lectureParts[1]);
    int finishTime = int.Parse(lectureParts[2]);

    lectures.Add(new Lecture
    {
        Name = name,
        StartTime = startTime,
        FinishTime = finishTime
    });
}

lectures = lectures.OrderBy(l => l.FinishTime).ToList();

List<Lecture> result = new();

result.Add(lectures.First());

foreach (Lecture lecture in lectures.Skip(1))
{
    Lecture lastLecture = result.Last();

    if (lastLecture.FinishTime >= lecture.StartTime) continue;

    result.Add(lecture);
}

Console.WriteLine($"Lectures ({result.Count}):");

result.ForEach(l => Console.WriteLine($"{l.StartTime}-{l.FinishTime} -> {l.Name}"));