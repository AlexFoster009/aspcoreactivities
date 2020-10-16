/*
    This interface will handle the activities model so we can get strong typing.
    and us var: Activity for example. this allows us to have strong typing over an
    object, we model how the object should look, and then we implement it.
 */

export interface IActivity {
    id: string;
    title: string;
    description: string;
    category: string;
    date: Date;
    city: string;
    venue: string;
}