﻿/**
 * File: permutations_ii.cs
 * Created Time: 2023-04-24
 * Author: hpstory (hpstory1024@163.com)
 */

using hello_algo.utils;
using NUnit.Framework;

namespace hello_algo.chapter_backtracking; 

public class permutations_ii {
    /* 回溯算法：全排列 II */
    public static void backtrack(List<int> state, int[] choices, bool[] selected, List<List<int>> res) {
        // 当状态长度等于元素数量时，记录解
        if (state.Count == choices.Length) {
            res.Add(new List<int>(state));
            return;
        }
        // 遍历所有选择
        ISet<int> duplicated = new HashSet<int>();
        for (int i = 0; i < choices.Length; i++) {
            int choice = choices[i];
            // 剪枝：不允许重复选择元素 且 不允许重复选择相等元素
            if (!selected[i] && !duplicated.Contains(choice)) {
                // 尝试
                duplicated.Add(choice); // 记录选择过的元素值
                selected[i] = true; // 做出选择
                state.Add(choice); // 更新状态
                backtrack(state, choices, selected, res);
                // 回退
                selected[i] = false; // 撤销选择
                state.RemoveAt(state.Count - 1); // 恢复到之前的状态
            }
        }
    }
    [Test]
    public void Test() {
        int[] nums = { 1, 2, 2 };
        List<List<int>> res = new List<List<int>>();

        // 回溯算法
        backtrack(new List<int>(), nums, new bool[nums.Length], res);

        Console.WriteLine("输入数组 nums = " + string.Join(", ", nums));
        Console.WriteLine("所有排列 res = ");
        foreach (List<int> permutation in res) {
            PrintUtil.PrintList(permutation);
        }
    }
}
