use std::collections::HashMap;
struct Solution;

fn main() {
    println!("{}", Solution::roman_to_int(String::from("IX")));
    println!("{}", Solution::roman_to_int(String::from("MMMCMXCIX")));
    println!("{}", Solution::roman_to_int(String::from("XCVII")));
}

impl Solution {
    pub fn roman_to_int(s: String) -> i32 {
        let mut val = HashMap::new(); 
        val.insert('I', 1);
        val.insert('V', 5);
        val.insert('X', 10);
        val.insert('L', 50);
        val.insert('C', 100);
        val.insert('D', 500);
        val.insert('M', 1000);

        let mut total = 0;
        let dig: Vec<char> = s.chars().collect();
        
        for i in 0..dig.len() {
            if i > 0 && val[&dig[i]] / 10 == val[&dig[i-1]] || i > 0 && val[&dig[i]] / 5 == val[&dig[i-1]] {
                continue; //Este valor ya se sumo
            }
            if i == dig.len()-1 {
                total = total + val[&dig[i]];
                continue;
            }
            if val[&dig[i]] * 10 == val[&dig[i+1]] || val[&dig[i]] * 5 == val[&dig[i+1]] {
                total = total + (val[&dig[i+1]] - val[&dig[i]]);
            } else {
                total = total + val[&dig[i]];
            }
        }
        return total;
    }
}
