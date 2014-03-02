coins = [200, 100, 50, 20, 10, 5, 2, 1]

def change(n, coins):
	if n == 0: return 1
	if n < 0: return 0
	if not coins: return 0
	return change(n, coins[1:]) + change(n-coins[0], coins)

print change(200, coins)