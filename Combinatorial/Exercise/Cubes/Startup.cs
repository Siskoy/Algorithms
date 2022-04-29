using System.Text;

string? colorsInput = Console.ReadLine();

if (colorsInput is null) return;

int[] colors = colorsInput
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .OrderBy(c => c)
        .ToArray();

HashSet<string> result = new();
HashSet<string> allPossibleCubes = new();

Permute(colors, 0, 11);

Console.WriteLine(result.Count);

void Permute(int[] arr, int start, int end)
{
    MarkCube();

    for (int left = end - 1; left >= start; left--)
    {
        for (int right = left + 1; right <= end; right++)
        {
            if (arr[left] == arr[right]) continue;

            Swap(ref arr[left], ref arr[right]);
            Permute(arr, left + 1, end);
        }

        int firstElement = arr[left];
        for (var i = left; i <= end - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        arr[end] = firstElement;
    }
}

static void Swap<T>(ref T first, ref T second)
{
    (second, first) = (first, second);
}

void MarkCube()
{
    Cube newCube = new()
    {
        FrontTop = colors[0],
        FrontRight = colors[1],
        FrontBottom = colors[2],
        FrontLeft = colors[3],
        BackTop = colors[4],
        BackRight = colors[5],
        BackBottom = colors[6],
        BackLeft = colors[7],
        TopLeft = colors[8],
        TopRight = colors[9],
        BottomLeft = colors[10],
        BottomRight = colors[11]
    };

    string cube = ConvertCubeToString(newCube);

    if (allPossibleCubes.Contains(cube)) return;

    result.Add(cube);

    for (int az = 0; az < 3; az++)
    {
        allPossibleCubes.Add(cube);
        newCube = AzimuthRotate(newCube);
        cube = ConvertCubeToString(newCube);

        for (int el = 0; el < 3; el++)
        {
            allPossibleCubes.Add(cube);
            newCube = ElevationRotate(newCube);
            cube = ConvertCubeToString(newCube);

            for (int roll = 0; roll < 4; roll++)
            {
                allPossibleCubes.Add(cube);
                newCube = RollRotate(newCube);
                cube = ConvertCubeToString(newCube);
            }
        }
    }
}

string ConvertCubeToString(Cube cube)
{
    StringBuilder sb = new();

    sb.Append(cube.FrontTop);
    sb.Append(cube.FrontRight);
    sb.Append(cube.FrontLeft);
    sb.Append(cube.FrontBottom);
    sb.Append(cube.BackTop);
    sb.Append(cube.BackRight);
    sb.Append(cube.BackLeft);
    sb.Append(cube.BackBottom);
    sb.Append(cube.TopRight);
    sb.Append(cube.TopLeft);
    sb.Append(cube.BottomRight);
    sb.Append(cube.BottomLeft);

    return sb.ToString();
}

Cube AzimuthRotate(Cube cube)
{
    return new Cube()
    {
        FrontTop = cube.TopRight,
        TopLeft = cube.FrontTop,
        BackTop = cube.TopLeft,
        TopRight = cube.BackTop,
        FrontLeft = cube.FrontRight,
        BackLeft = cube.FrontLeft,
        BackRight = cube.BackLeft,
        FrontRight = cube.BackRight,
        FrontBottom = cube.BottomRight,
        BottomLeft = cube.FrontBottom,
        BackBottom = cube.BottomLeft,
        BottomRight = cube.BackBottom
    };
}

Cube ElevationRotate(Cube cube)
{
    return new Cube()
    {
        FrontTop = cube.BackTop,
        FrontBottom = cube.FrontTop,
        BackBottom = cube.FrontBottom,
        BackTop = cube.BackBottom,
        FrontLeft = cube.TopLeft,
        BottomLeft = cube.FrontLeft,
        BackLeft = cube.BottomLeft,
        TopLeft = cube.BackLeft,
        FrontRight = cube.TopRight,
        BottomRight = cube.FrontRight,
        BackRight = cube.BottomRight,
        TopRight = cube.BackRight
    };
}

Cube RollRotate(Cube cube)
{
    return new Cube()
    {
        FrontTop = cube.FrontRight,
        FrontLeft = cube.FrontTop,
        FrontBottom = cube.FrontLeft,
        FrontRight = cube.FrontBottom,
        BackTop = cube.BackRight,
        BackLeft = cube.BackTop,
        BackBottom = cube.BackLeft,
        BackRight = cube.BackBottom,
        TopLeft = cube.TopRight,
        BottomLeft = cube.TopLeft,
        BottomRight = cube.BottomLeft,
        TopRight = cube.BottomRight
    };
}
