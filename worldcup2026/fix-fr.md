#bug 1

La méthode Predict dans PredictionService.cs calcule la force d'une équipe en soustrayant le DefenseRating du AttackRating.
C'est incorrect — la force globale d'une équipe devrait combiner l'attaque et la défense.
Corrige le calcul de la force pour qu'il additionne AttackRating et DefenseRating pour les deux équipes (domicile et extérieur).


#bug2
La méthode Predict dans PredictionService.cs ne retourne jamais un résultat de match nul.
Quand homeStrength est égal à awayStrength, le code passe directement à la déclaration de victoire de l'équipe extérieure.
Ajoute une condition else if pour gérer les forces égales en retournant "Match nul !".


#démo 3

✅ 4 — Qu'est-ce que ⚡ Comparaison de Performance ?
C'est une page qui démontre pourquoi le choix d'algorithme est important en utilisant System.Diagnostics.Stopwatch :

SlowStandingsService	FastStandingsService
Structure de données	List<Standing> — recherche linéaire avec FirstOrDefault() à chaque fois	Dictionary<string, int> — recherche O(1) par nom d'équipe
Algorithme	Boucle 10 000 itérations (simule un travail coûteux), et à chaque itération parcourt la liste pour chaque équipe avec FirstOrDefault() — O(n) par recherche	Un seul passage sur tous les matchs, recherche O(1) via dictionnaire
Résultat	Lent (des centaines de ms)	Rapide (< 1 ms)
Ce que ça fait : Quand vous cliquez "Lancer le test", les deux services sont chronométrés avec Stopwatch et le résultat s'affiche dans un tableau : "La version rapide est X× plus rapide !"

Leçon de la démo : Choisir la bonne structure de données (Dictionary vs List) et éviter les recalculs inutiles peut rendre le code plus rapide de plusieurs ordres de grandeur.



#Tests Unitaires

dans une nouvelle branch feat/unittest dans le woldcupunittest
Ajoute des tests xUnit complets au projet woldcupunittest pour mon application Blazor World Cup 2026. Le projet de test référence déjà xUnit 2.9.3 et cible net10.0. Tu devras ajouter une référence de projet vers le projet worldcup2026.

Écris des tests pour les éléments suivants :

Tests de PredictionService :
- Teste que quand l'équipe domicile a une force totale (AttackRating + DefenseRating) supérieure à l'extérieur, le résultat contient le nom de l'équipe domicile et "wins"
- Teste que quand l'équipe extérieur a une force totale supérieure, le résultat contient le nom de l'équipe extérieur et "wins"
- Teste que quand les deux équipes ont une force totale égale, le résultat contient "draw" (ce test devrait ÉCHOUER initialement — il prouve que le Bug 2 existe)
- Teste que le calcul de force utilise l'addition et non la soustraction (ce test devrait ÉCHOUER initialement — il prouve que le Bug 1 existe)

Crée des classes de test séparées par service. Utilise des noms de méthodes de test descriptifs. 
Utilise le pattern Arrange-Act-Assert. Pour les services qui ont besoin de WorldCupDataService, 
crée des mocks ou des instances de test avec des données connues.



#6 local Model usage