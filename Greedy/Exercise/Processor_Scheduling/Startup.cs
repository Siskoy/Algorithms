string? taskCountInput = Console.ReadLine();

if (taskCountInput is null) return;

int taskCount = int.Parse(taskCountInput.Replace("Tasks: ", ""));

List<Task> tasks = new(taskCount);

for (int i = 0; i < taskCount; i++)
{
    string? taskInput = Console.ReadLine();

    if (taskInput is null) continue;

    string[] taskParts = taskInput.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

    if (taskParts.Length != 2) continue;

    tasks.Add(new Task
    {
        Number = i + 1,
        Value = int.Parse(taskParts[0]),
        Deadline = int.Parse(taskParts[1])
    });
}

int maxSteps = tasks.Max(t => t.Deadline);

List<Task> optimalTasks = tasks
    .OrderByDescending(t => t.Value)
    .Take(maxSteps)
    .OrderBy(t => t.Deadline)
    .ToList();

string scheduleOutput = string.Join(" -> ", optimalTasks.Select(t => t.Number));

Console.WriteLine($"Optimal schedule: {scheduleOutput}");

int totalValue = optimalTasks.Sum(t => t.Value);

Console.WriteLine($"Total value: {totalValue}");