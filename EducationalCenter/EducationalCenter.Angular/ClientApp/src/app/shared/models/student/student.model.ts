import { StudentGroup } from "../studentGroup/studentGroup.model";

export interface Student {
    id: number,
    fio: string,
    dateOfBirth: Date,
    groupId: number | null,
    group: StudentGroup
}