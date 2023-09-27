import { StyleSheet } from 'react-native';
import { Dimensions } from 'react-native';

const { height } = Dimensions.get("screen");
const height_logo = height * 0.28;
// const styles = StyleSheet.create({
//   container: {
//     flex: 1,
//     justifyContent: 'center',
//     alignItems: 'center',
//     backgroundColor: '#2cd18a'
//   },
//   photo: {
//     width: 150,
//     height: 150
//   }
// });

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#3CB371'
    },
    header: {
        flex: 1,
        justifyContent: 'flex-end',
        paddingHorizontal: 20,
        paddingBottom: 5
    },
    footer: {
        flex: 3,
        backgroundColor: '#fff',

        paddingHorizontal: 20,
        paddingVertical: 30
    },
    text_header: {
        color: '#fff',
        fontWeight: 'bold',
        fontSize: 30
    },
    text_footer: {
        color: '#05375a',
        fontSize: 18
    },
    action: {
        flexDirection: 'row',
        marginTop: 10,
        borderBottomWidth: 1,
        borderBottomColor: '#f2f2f2',
        paddingBottom: 5
    },
    actionError: {
        flexDirection: 'row',
        marginTop: 10,
        borderBottomWidth: 1,
        borderBottomColor: '#FF0000',
        paddingBottom: 5
    },
    textInput: {
        flex: 1,
        paddingLeft: 10,
        color: '#05375a',
    },
    errorMsg: {
        color: '#FF0000',
        fontSize: 14,
    },
    button: {
        alignItems: 'center',
        marginTop: 50
    },
    signIn: {
        marginTop: 25,
        width: 150,
        height: 50,
        justifyContent: 'center',
        alignItems: 'center',
        padding: 10,
        borderRadius: 30,
        backgroundColor: '#3CB371',
    },
    textSign: {
        fontSize: 18,
        fontWeight: 'bold'
    },
    signUp: {
        marginTop: 5,
        color: '#3CB371',
        fontSize: 17
    },
});

export default styles;
