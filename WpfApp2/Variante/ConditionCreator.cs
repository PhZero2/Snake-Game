using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{

    public static class ConditionCreator
    {
        static ICondition lose = LoseGame();
        static Func<IConditionPotenciador> o = () => new MultiplyPotenciador(2, 10, valores);
        static Func<State, int> valores = (state) =>
         {
             switch (state)
             {
                 case State.Food: return 1;
                 case State.Food2: return 1;
                 case State.MenoScore: return -2;
                 default: return 0;
             }
         };
        static ICondition crecer = Crecer();

        public static ICondition Get() => EmptyCondition.Empty
                             .StateChecker(ReducirSnake(), State.FoodN)
                             .StateChecker(Score(-2), State.MenoScore)
                             .StateChecker(AddPotenciador2(o), State.Multi)
                             .ConcatWithMoverAction()
                             .StateChecker(crecer.ConcatWithColocar(State.Food).ConcatWithScore(1), State.Food)
                             .StateChecker(crecer.ConcatWithCrecerAction().ConcatWithScore(1), State.Food2)
                             .ExecutePotenciador()
                             .StateChecker(lose, State.Pared)
                             .ColisionChecker(lose)
                             .OuterChecker(lose);
        private static ICondition ExecutePotenciador(this ICondition condition)
        {
            return new PotenciadorBaseChecker(condition);
        }
        private static ICondition OuterChecker(this ICondition next, ICondition accion) =>
            new OutChecker(next, accion);
        private static ICondition StateChecker(this ICondition next, ICondition accion, State state) =>
            new StateChecker(next, accion, state);
        private static ICondition ColisionChecker(this ICondition next, ICondition accion) =>
            new ColisionChecker(next, accion);
        private static ICondition TailChecker(this ICondition next, ICondition accion) =>
            new TailChecker(next, accion);

        //private static ICondition AddPotenciador(IConditionPotenciador add) =>
        //    new AddPotenciadorAction(add);
        private static ICondition AddPotenciador2(Func<IConditionPotenciador> add) =>
            new AddPotenciadorAction(add);

        public static ICondition AdicionarElement(State elem) => new ColocarAction(elem);
        public static ICondition Score(int cant) => new ScoreAction(cant);
        public static ICondition LoseGame() => new LoseAction();
        public static ICondition ReducirSnake() => new ReducirAction();
        public static ICondition Mover() => new MoverAction();
        public static ICondition Crecer() => new CrecerAction();

        private class Pair : ICondition
        {
            ICondition a1, a2;
            public Pair(ICondition a1, ICondition a2)
            {
                this.a1 = a1;
                this.a2 = a2;
            }

            public void Execute(GameState gameState, Location futuro)
            {
                a1.Execute(gameState, futuro);
                a2.Execute(gameState, futuro);
            }
        }

        public static ICondition ConcatWithCrecerAction(this ICondition cond) =>
            new Pair(cond, new CrecerAction());
        public static ICondition ConcatWithLoseAction(this ICondition con) =>
            new Pair(con, new LoseAction());
        public static ICondition ConcatWithMoverAction(this ICondition con) =>
            new Pair(con, new MoverAction());
        public static ICondition ConcatWithReducirAction(this ICondition con) =>
            new Pair(con, new ReducirAction());
        public static ICondition ConcatWithScore(this ICondition con, int cant) =>
            new Pair(con, new ScoreAction(cant));
        public static ICondition ConcatWithColocar(this ICondition con, State sta) =>
            new Pair(con, new ColocarAction(sta));
        public static ICondition ConcatWithAdition(this ICondition con, State sta) =>
            new Pair(con, new AdicionarAction(sta));
        public static ICondition ConcatAction(this ICondition action, ICondition siguiente)
        {
            return new Pair(action, siguiente);
        }
    }
}
