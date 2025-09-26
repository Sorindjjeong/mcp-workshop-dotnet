using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// 원숭이 데이터 관리를 위한 정적 헬퍼 클래스
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static int randomPickCount = 0;
    private static readonly object lockObj = new();

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 비동기로 가져옵니다.
    /// </summary>
    public static async Task InitializeAsync()
    {
        // MCP 서버에서 데이터를 가져오는 부분은 실제 구현 시 HttpClient 등으로 대체
        monkeys = await FetchMonkeysFromMcpAsync();
    }

    /// <summary>
    /// 모든 원숭이 목록을 반환합니다.
    /// </summary>
    public static List<Monkey> GetMonkeys()
    {
        return monkeys ?? new List<Monkey>();
    }

    /// <summary>
    /// 이름으로 원숭이를 찾습니다.
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys?.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 랜덤 원숭이를 반환하고, 호출 횟수를 추적합니다.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        if (monkeys == null || monkeys.Count == 0)
            return null;
        lock (lockObj)
        {
            randomPickCount++;
        }
        var rand = new Random();
        return monkeys[rand.Next(monkeys.Count)];
    }

    /// <summary>
    /// 랜덤 원숭이 선택 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomPickCount()
    {
        lock (lockObj)
        {
            return randomPickCount;
        }
    }

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 가져오는 예시 메서드 (실제 구현 필요)
    /// </summary>
    private static async Task<List<Monkey>> FetchMonkeysFromMcpAsync()
    {
        // TODO: MCP 서버 API 연동 구현
        await Task.Delay(100); // 비동기 예시
        return new List<Monkey>();
    }
}
