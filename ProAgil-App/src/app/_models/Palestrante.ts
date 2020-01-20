import { RedeSocial } from './RedeSocial';
import { Evento } from './evento';

export interface Palestrante {
    id: number;
    nome: string;
    miniCurriculo: string;
    imagemUrl: string;
    telefone: string;
    email: string;
    redeSociais: RedeSocial[];
    palestranteEventos: Evento[];
}
